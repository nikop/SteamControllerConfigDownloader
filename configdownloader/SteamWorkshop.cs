using SteamKit2;
using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configdownloader
{
    public class SteamWorkshop : ClientMsgHandler
    {
        public class WorkshopInfoCallback : CallbackMsg
        {

            public class WorkshopItem
            {
                public ulong PublishedFileID { get; set; }
                
                public ulong ManifestID { get; set; }
            }

            public List<WorkshopItem> Items { get; } = new List<WorkshopItem>();

            internal WorkshopInfoCallback(JobID job, EResult result, IEnumerable<WorkshopItem> items)
            {
                JobID = job;

                Items.AddRange(items);
            }
        }

        public AsyncJob<WorkshopInfoCallback> RequestInfo(uint app, ulong workshopid)
        {
            var msg = new ClientMsgProtobuf<CMsgClientWorkshopItemInfoRequest>(EMsg.ClientWorkshopItemInfoRequest);
            msg.SourceJobID = Client.GetNextJobID();
            msg.Body.app_id = app;
            msg.Body.last_time_updated = 0;
            msg.Body.workshop_items.Add(new CMsgClientWorkshopItemInfoRequest.WorkshopItem() { published_file_id = workshopid, time_updated = 0 });

            Client.Send(msg);

            return new AsyncJob<WorkshopInfoCallback>(Client, msg.SourceJobID);
        }

        public override void HandleMsg(IPacketMsg packetMsg)
        {
            switch (packetMsg.MsgType)
            {
                case EMsg.ClientWorkshopItemInfoResponse:
                    HandleWorkshopItemInfoResponse(packetMsg);
                    break;
            }
        }

        private void HandleWorkshopItemInfoResponse(IPacketMsg packetMsg)
        {
            var msg = new ClientMsgProtobuf<CMsgClientWorkshopItemInfoResponse>(packetMsg);

            EResult err = (EResult)msg.Body.eresult;

            var items = msg.Body.workshop_items.Select(x => new WorkshopInfoCallback.WorkshopItem()
            {
                PublishedFileID = x.published_file_id,
                ManifestID = x.manifest_id
            });

            Client.PostCallback(new WorkshopInfoCallback(msg.TargetJobID, (EResult) msg.Body.eresult, items));
        }
    }
}
