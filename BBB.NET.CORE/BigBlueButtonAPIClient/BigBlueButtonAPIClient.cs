using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Helpers;
using BBB.NET.CORE.Requests.BreakoutRoom;
using BBB.NET.CORE.Requests.Chat;
using BBB.NET.CORE.Requests.Meeting;
using BBB.NET.CORE.Requests.Notification;
using BBB.NET.CORE.Requests.Recording;
using BBB.NET.CORE.Requests.Slides;
using BBB.NET.CORE.Requests.Translation;
using BBB.NET.CORE.Requests.User;
using BBB.NET.CORE.Requests.Webhook;
using BBB.NET.CORE.Responses.BreakoutRoom;
using BBB.NET.CORE.Responses.Chat;
using BBB.NET.CORE.Responses.Meeting;
using BBB.NET.CORE.Responses.Notification;
using BBB.NET.CORE.Responses.Recording;
using BBB.NET.CORE.Responses.Slides;
using BBB.NET.CORE.Responses.Translation;
using BBB.NET.CORE.Responses.User;
using BBB.NET.CORE.Responses.Webhook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.BigBlueButtonAPIClient
{
    public class BigBlueButtonAPIClient
    {
        
        private readonly HttpClient httpClient;
        private readonly UrlBuilder urlBuilder;


        public BigBlueButtonAPIClient(BigBlueButtonAPISettings settings, HttpClient httpClient)
        {
            this.urlBuilder = new UrlBuilder(settings);
            this.httpClient = httpClient;
        }


        #region Meeting Management
        public async Task<CreateMeetingResponse> CreateMeetingAsync(CreateMeetingRequest request)
        {
            return await HttpGetAsync<CreateMeetingResponse>("create", request);
        }

        public async Task<EndMeetingResponse> EndMeetingAsync(EndMeetingRequest request)
        {
            return await HttpGetAsync<EndMeetingResponse>("end", request);
        }

        public async Task<GetMeetingInfoResponse> GetMeetingInfoAsync(GetMeetingInfoRequest request)
        {
            return await HttpGetAsync<GetMeetingInfoResponse>("getMeetingInfo", request);
        }

        public async Task<IsMeetingRunningResponse> IsMeetingRunningAsync(IsMeetingRunningRequest request)
        {
            return await HttpGetAsync<IsMeetingRunningResponse>("isMeetingRunning", request);
        }

        public async Task<GetMeetingsResponse> GetMeetingsAsync()
        {
            return await HttpGetAsync<GetMeetingsResponse>("getMeetings");
        }

        public async Task<string> JoinMeetingAsync(JoinMeetingRequest request)
        {
            var url = urlBuilder.Build("join", request);
            return url;
        }
        #endregion


        #region Recording Management
        public async Task<GetRecordingsResponse> GetRecordingsAsync(GetRecordingsRequest request)
        {
            return await HttpGetAsync<GetRecordingsResponse>("getRecordings", request);
        }

        public async Task<PublishRecordingsResponse> PublishRecordingsAsync(PublishRecordingsRequest request)
        {
            return await HttpGetAsync<PublishRecordingsResponse>("publishRecordings", request);
        }

        public async Task<DeleteRecordingsResponse> DeleteRecordingsAsync(DeleteRecordingsRequest request)
        {
            return await HttpGetAsync<DeleteRecordingsResponse>("deleteRecordings", request);
        }

        public async Task<UpdateRecordingsResponse> UpdateRecordingsAsync(UpdateRecordingsRequest request)
        {
            return await HttpGetAsync<UpdateRecordingsResponse>("updateRecordings", request);
        }

        public async Task<PauseRecordingResponse> PauseRecordingAsync(PauseRecordingRequest request)
        {
            return await HttpGetAsync<PauseRecordingResponse>("pauseRecording", request);
        }

        public async Task<ResumeRecordingResponse> ResumeRecordingAsync(ResumeRecordingRequest request)
        {
            return await HttpGetAsync<ResumeRecordingResponse>("resumeRecording", request);
        }

        public async Task<AddRecordingMetadataResponse> AddRecordingMetadataAsync(AddRecordingMetadataRequest request)
        {
            return await HttpGetAsync<AddRecordingMetadataResponse>("addRecordingMetadata", request);
        }

        public async Task<ExtendRecordingDurationResponse> ExtendRecordingDurationAsync(ExtendRecordingDurationRequest request)
        {
            return await HttpGetAsync<ExtendRecordingDurationResponse>("extendRecordingDuration", request);
        }

        public async Task<GetRecordingFormatsResponse> GetRecordingFormatsAsync(GetRecordingFormatsRequest request)
        {
            return await HttpGetAsync<GetRecordingFormatsResponse>("getRecordingFormats", request);
        }
        #endregion


        #region User Management
        public async Task<MuteUserResponse> MuteUserAsync(MuteUserRequest request)
        {
            return await HttpGetAsync<MuteUserResponse>("muteUser", request);
        }

        public async Task<KickUserResponse> KickUserAsync(KickUserRequest request)
        {
            return await HttpGetAsync<KickUserResponse>("kickUser", request);
        }

        public async Task<MuteAllUsersResponse> MuteAllUsersAsync(MuteAllUsersRequest request)
        {
            return await HttpGetAsync<MuteAllUsersResponse>("muteAllUsers", request);
        }

        public async Task<LockUserResponse> LockUserAsync(LockUserRequest request)
        {
            return await HttpGetAsync<LockUserResponse>("lockUser", request);
        }

        public async Task<LockSettingsResponse> LockSettingsAsync(LockSettingsRequest request)
        {
            return await HttpGetAsync<LockSettingsResponse>("lockSettings", request);
        }

        public async Task<RemoveUserResponse> RemoveUserAsync(RemoveUserRequest request)
        {
            return await HttpGetAsync<RemoveUserResponse>("removeUser", request);
        }
        #endregion


        #region Breakout Room Management
        public async Task<CreateBreakoutRoomsResponse> CreateBreakoutRoomsAsync(CreateBreakoutRoomsRequest request)
        {
            return await HttpGetAsync<CreateBreakoutRoomsResponse>("createBreakoutRooms", request);
        }

        public async Task<GetBreakoutRoomsResponse> GetBreakoutRoomsAsync(GetBreakoutRoomsRequest request)
        {
            return await HttpGetAsync<GetBreakoutRoomsResponse>("getBreakoutRooms", request);
        }

        public async Task<EndBreakoutRoomsResponse> EndBreakoutRoomsAsync(EndBreakoutRoomsRequest request)
        {
            return await HttpGetAsync<EndBreakoutRoomsResponse>("endBreakoutRooms", request);
        }

        public async Task<JoinBreakoutRoomResponse> JoinBreakoutRoomAsync(JoinBreakoutRoomRequest request)
        {
            return await HttpGetAsync<JoinBreakoutRoomResponse>("joinBreakoutRoom", request);
        }

        public async Task<AssignUserToBreakoutRoomResponse> AssignUserToBreakoutRoomAsync(AssignUserToBreakoutRoomRequest request)
        {
            return await HttpGetAsync<AssignUserToBreakoutRoomResponse>("assignUserToBreakoutRoom", request);
        }

        public async Task<BreakoutRoomInfoResponse> BreakoutRoomInfoAsync(BreakoutRoomInfoRequest request)
        {
            return await HttpGetAsync<BreakoutRoomInfoResponse>("getBreakoutRoomInfo", request);
        }

        public async Task<BreakoutRoomParticipantsResponse> BreakoutRoomParticipantsAsync(BreakoutRoomParticipantsRequest request)
        {
            return await HttpGetAsync<BreakoutRoomParticipantsResponse>("getBreakoutRoomParticipants", request);
        }

        public async Task<CloseBreakoutRoomResponse> CloseBreakoutRoomAsync(CloseBreakoutRoomRequest request)
        {
            return await HttpGetAsync<CloseBreakoutRoomResponse>("closeBreakoutRoom", request);
        }

        public async Task<ExtendBreakoutRoomResponse> ExtendBreakoutRoomAsync(ExtendBreakoutRoomRequest request)
        {
            return await HttpGetAsync<ExtendBreakoutRoomResponse>("extendBreakoutRoom", request);
        }
        #endregion


        #region Slides Management
        public async Task<InsertSlideResponse> InsertSlideAsync(InsertSlideRequest request)
        {
            return await HttpPostFileAsync<InsertSlideResponse>("insertDocument", request);
        }

        public async Task<RemoveSlideResponse> RemoveSlideAsync(RemoveSlideRequest request)
        {
            return await HttpGetAsync<RemoveSlideResponse>("removeDocument", request);
        }

        public async Task<GetSlidesResponse> GetSlidesAsync(GetSlidesRequest request)
        {
            return await HttpGetAsync<GetSlidesResponse>("getSlides", request);
        }

        public async Task<SetSlideAsCurrentResponse> SetSlideAsCurrentAsync(SetSlideAsCurrentRequest request)
        {
            return await HttpGetAsync<SetSlideAsCurrentResponse>("setSlideAsCurrent", request);
        }

        public async Task<ReorderSlidesResponse> ReorderSlidesAsync(ReorderSlidesRequest request)
        {
            return await HttpGetAsync<ReorderSlidesResponse>("reorderSlides", request);
        }

        public async Task<ClearAllSlidesResponse> ClearAllSlidesAsync(ClearAllSlidesRequest request)
        {
            return await HttpGetAsync<ClearAllSlidesResponse>("clearAllSlides", request);
        }
        #endregion


        #region Chat Management
        public async Task<SendChatMessageResponse> SendChatMessageAsync(SendChatMessageRequest request)
        {
            return await HttpGetAsync<SendChatMessageResponse>("sendChatMessage", request);
        }

        public async Task<GetChatMessagesResponse> GetChatMessagesAsync(GetChatMessagesRequest request)
        {
            return await HttpGetAsync<GetChatMessagesResponse>("getChatMessages", request);
        }

        public async Task<ClearChatMessagesResponse> ClearChatMessagesAsync(ClearChatMessagesRequest request)
        {
            return await HttpGetAsync<ClearChatMessagesResponse>("clearChatMessages", request);
        }
        #endregion


        #region Webhook Management
        public async Task<CreateWebhookResponse> CreateWebhookAsync(CreateWebhookRequest request)
        {
            return await HttpGetAsync<CreateWebhookResponse>("createWebhook", request);
        }

        public async Task<DeleteWebhookResponse> DeleteWebhookAsync(DeleteWebhookRequest request)
        {
            return await HttpGetAsync<DeleteWebhookResponse>("deleteWebhook", request);
        }

        public async Task<ListWebhooksResponse> ListWebhooksAsync(ListWebhooksRequest request)
        {
            return await HttpGetAsync<ListWebhooksResponse>("listWebhooks", request);
        }

        public async Task<PauseWebhookResponse> PauseWebhookAsync(PauseWebhookRequest request)
        {
            return await HttpGetAsync<PauseWebhookResponse>("pauseWebhook", request);
        }

        public async Task<ResumeWebhookResponse> ResumeWebhookAsync(ResumeWebhookRequest request)
        {
            return await HttpGetAsync<ResumeWebhookResponse>("resumeWebhook", request);
        }

        public async Task<UpdateWebhookResponse> UpdateWebhookAsync(UpdateWebhookRequest request)
        {
            return await HttpGetAsync<UpdateWebhookResponse>("updateWebhook", request);
        }
        #endregion


        #region Notification Management
        public async Task<SendNotificationResponse> SendNotificationAsync(SendNotificationRequest request)
        {
            return await HttpGetAsync<SendNotificationResponse>("sendNotification", request);
        }

        public async Task<GetNotificationStatusResponse> GetNotificationStatusAsync(GetNotificationStatusRequest request)
        {
            return await HttpGetAsync<GetNotificationStatusResponse>("getNotificationStatus", request);
        }
        #endregion


        #region Translation Management
        public async Task<AddTranslationResponse> AddTranslationAsync(AddTranslationRequest request)
        {
            return await HttpGetAsync<AddTranslationResponse>("addTranslation", request);
        }

        public async Task<RemoveTranslationResponse> RemoveTranslationAsync(RemoveTranslationRequest request)
        {
            return await HttpGetAsync<RemoveTranslationResponse>("removeTranslation", request);
        }
        #endregion













        #region HTTP Methods
        private async Task<T> HttpGetAsync<T>(string method, BaseRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var result = await HttpGetAsync<T>(url);
            return result;
        }

        private async Task<T> HttpGetAsync<T>(string url)
        {
            var response = await httpClient.GetAsync(url);
            var xmlOrJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response XML/JSON: " + xmlOrJson);

            if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

            if (xmlOrJson.StartsWith("<"))
            {
                return XmlHelper.FromXml<T>(xmlOrJson);
            }
            else
            {
                var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                return wrapper.response;
            }
        }



        private async Task<T> HttpPostFileAsync<T>(string method, BasePostFileRequest request)
        {
            var url = urlBuilder.Build(method, request);
            using var content = new MultipartFormDataContent
    {
        { new ByteArrayContent(request.file.FileData), "file", request.file.FileName }
    };
            var response = await httpClient.PostAsync(url, content);
            var xmlOrJson = await response.Content.ReadAsStringAsync();

            if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

            if (xmlOrJson.StartsWith("<"))
            {
                return XmlHelper.FromXml<T>(xmlOrJson);
            }
            else
            {
                var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                return wrapper.response;
            }
        }

        #endregion

    }
}
