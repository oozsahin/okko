using Microsoft.Extensions.Configuration;
using Okko.Shared.Helpers;
using Okko.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Okko.Shared.Data
{
    public class DepositService : IDepositService
    {
        private IAPIHelper _apiHelper;
        private readonly IConfiguration _config = null;
        private DefaultSettings _defaultSettings = new DefaultSettings();

        public DepositService(IAPIHelper apiHelper, IConfiguration config)
        {
            _apiHelper = apiHelper;
            _config = config;
        }

        public async Task<List<DepositModel>> GetSomeDeposits()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(String.Concat(_defaultSettings.APIBaseUrl, _defaultSettings.APIPathDeposit, "GetSomeDeposits")))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<DepositModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
                //if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    var jsonString = await response.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
                //}
                //return null;
            }
        }
        //public async Task PostSale(SaleModel sale)
        //{
        //    using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Sale", sale))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Log successful call?
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}

    }
}
