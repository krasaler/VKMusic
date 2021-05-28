using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKMusic
{
    public class VKAuthorize
    {
        private string appId;
        private string Scope;
        private string accessToken;
        private string user_id;
        private WebAuthorized authorize;
        public delegate void EndRequestEventHandler(string AccessToken, string user_id);
        public event EndRequestEventHandler EndRequestEvent;
        public VKAuthorize(string appId, string Scope)
        {
            this.appId = appId;
            this.Scope = Scope;
        }

        public void Authorized()
        {
            string vkUri = "https://oauth.vk.com/authorize?client_id=" + appId + "&scope=" + Scope + "&redirect_uri=http://oauth.vk.com/blank.html" +
                "&display=touch&response_type=token";
            Uri requestUri = new Uri(vkUri);
            Uri callbackUri = new Uri("http://oauth.vk.com/blank.html");
            authorize = new WebAuthorized(requestUri, callbackUri);
            authorize.SuccesEvent += result_SuccesEvent;
            authorize.ShowDialog();
        }
        void result_SuccesEvent(Uri result)
        {
            string responseString = result.ToString();
            authorize.Close();
            string[] responseContent = responseString.Split('=', '&');
            accessToken = responseContent[1];
            user_id = responseContent[5];
            EndRequestEvent(accessToken, user_id);
        }
    }
}
