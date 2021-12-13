using System.Text;
using System.Text.Json;
using WebUI.Dtos;

namespace WebUI.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new(JsonSerializerDefaults.Web);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoriesDto;
            var response = await _httpClient.GetAsync("categories");

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                categoriesDto = JsonSerializer.Deserialize<IEnumerable<CategoryDto>>(jsonData, _options);
            }
            else categoriesDto = null;

            return categoriesDto;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync("categories/"+id);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CategoryDto>(jsonData, _options);
            }

            return null;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("categories", stringContent);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                categoryDto = JsonSerializer.Deserialize<CategoryDto>(jsonData, _options);
                
                return categoryDto;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("categories", stringContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync("categories/" + id);
            return response.IsSuccessStatusCode;
        }
    }
}
