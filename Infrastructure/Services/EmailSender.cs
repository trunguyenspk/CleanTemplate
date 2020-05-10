using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EbatchSheetEmailSender : IEbatchSheetEmailSender
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EbatchSheetEmailSender> _logger;

        public EbatchSheetEmailSender(IHttpContextAccessor httpContext, IHttpClientFactory clientFactory,
            IConfiguration configuration, ILogger<EbatchSheetEmailSender> logger)
        {
            _httpContext = httpContext;
            _clientFactory = clientFactory;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task SendEmail(EbatchSheet ebatchSheet)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _configuration["EmailTriggerURL"]);
            request.Headers.Add("Accept", "application/json");

            var req = _httpContext.HttpContext.Request;
            string itemUrl = string.Format("{0}://{1}/form?id={2}", req.Scheme, req.Host, ebatchSheet.Id);

            EbatchSheetUpdateStateMailContent emailContent = new EbatchSheetUpdateStateMailContent
            {
                Body = itemUrl,
                NextState = ebatchSheet.CurrentState.Value
            };

            string content = JsonConvert.SerializeObject(emailContent);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("UPDATE_EBATCHSHEET - SEND EMAIL FAILED {@request}", request);
            }
            else 
            {
                _logger.LogInformation("UPDATE_EBATCHSHEET: {ebatchId} - {@BODY} successfully to {newStatus} ", ebatchSheet.Id, request, ebatchSheet.CurrentState);
            }
        }
    }
}
