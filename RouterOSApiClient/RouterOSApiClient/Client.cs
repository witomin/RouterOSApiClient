using RouterOSApiClient.REST.Types;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RouterOSApiClient {
    public class Client : API {
        private HttpClient httpClient;
        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public Client(APIContext context) : base(context) {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"{Assembly.GetExecutingAssembly()?.GetName()?.Name}/{Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString()}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetCredentials(context.Config.Login, context.Config.Password));
        }
        /// <summary>
        /// Получить Credentials для Basic авторизации
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        private static string GetCredentials(string login, string password) {
            return Base64Encode($"{login}:{password}");
        }
        /// <summary>
        /// Кодировать строку в Base65
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns></returns>
        private static string Base64Encode(string text) {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
        /// <summary>
        /// Получить правила NAT
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse<List<NatRule>>?> GetNatRulesAsync() {
            var response = await httpClient.GetAsync($"{Context.Config.BaseURL}/rest/ip/firewall/nat");
            return await APIResponse<List<NatRule>>.ReadApiResponseAsync(response);
        }
        /// <summary>
        /// Получить правила NAT
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse<NatRule>?> GetNatRulesAsync(string id) {
            var response = await httpClient.GetAsync($"{Context.Config.BaseURL}/rest/ip/firewall/nat/{id}");
            return await APIResponse<NatRule>.ReadApiResponseAsync(response);
        }
        /// <summary>
        /// Изменить правило NAT
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public async Task<APIResponse<NatRule>?> EditNatRuleAsync(NatRule rule) {
            var content = new ObjectContent(typeof(NatRule), rule, jsonSerializerOptions);
            var response = await httpClient.PatchAsync($"{Context.Config.BaseURL}/rest/ip/firewall/nat/{rule.Id}", content);
            return await APIResponse<NatRule>.ReadApiResponseAsync(response);
        }
    }
}
