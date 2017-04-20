using System;
using FormsTest.Helpers;
using Newtonsoft.Json;

namespace FormsTest
{
    public class Item : ObservableObject
    {
        string id = string.Empty;

        [JsonIgnore]
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string imageurl = string.Empty;
        public string ImageUrl
        {
            get { return imageurl; }
            set { SetProperty(ref imageurl, value); }
        }

        DateTime postTime;
        public DateTime PostTime
        {
            get { return postTime; }
            set { SetProperty(ref postTime, value); }
        }

        [JsonIgnore]
        public string TimeAgo
        {
            get { return PostTime.TimeAgo(); }
        }
    }
}
