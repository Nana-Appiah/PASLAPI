using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using Json.Net;

using LivenessAPI.repositories;

namespace LivenessAPI.EndPoint
{
    //this class will serve the endpoints
    public class Verification
    {
        private string baseURI = "https://selfie.imsgh.org:9020/api/v1/third-party/verification";
        public async Task<bool> LivenessVerificationAsync(PayLoad payLoad)
        {
            bool blnStatus = false;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringPayload = JsonConvert.SerializeObject(payLoad);
                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(baseURI, content).Result;

                var ct = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    blnStatus = true;
                }
                else { blnStatus = false; }

                return blnStatus;
            }
            catch (Exception x)
            {
                return blnStatus;
            }
        }
    
        public async Task<data> LivenessVerificationWithDataAsync(PayLoad payLoad)
        {
            //second endpoint
            data o = null;

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseURI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringPayload = JsonConvert.SerializeObject(payLoad);
                var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(baseURI, content).Result;

                var ct = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var x = JObject.Parse(ct);
                    var dt = JsonConvert.DeserializeObject<data>(ct);

                    //format data and send response of request to client
                    o = new data();
                    o.transactionGuid = x["data"]["transactionGuid"].ToString();
                    o.shortGuid = x["data"]["shortGuid"].ToString();
                    o.requestTimestamp = x["data"]["requestTimestamp"].ToString();
                    o.responseTimestamp = x["data"]["responseTimestamp"].ToString();
                    o.verified = x["data"]["verified"].ToString();
                    o.center = x["data"]["center"].ToString();
                    o.isException = x["data"]["isException"].ToString();
                    o.person = x["data"]["person"].ToObject<Person>();
                    o.success = x["success"].ToString();
                    o.code = x["code"].ToString();
                }

                return o;
            }
            catch (Exception x)
            {
                return o;
            }

        }

    }
}
