﻿using Caasiope.Explorer.JSON.API.Internals;
using Caasiope.Explorer.JSON.API.Responses;
using Helios.JSON;

namespace Caasiope.Explorer.JSON.API.Requests
{
    public class SubscribeRequest : Request<SubscribeResponse>
    {
        public Topic Topic;
    }
}