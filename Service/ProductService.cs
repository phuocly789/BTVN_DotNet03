using System.Text.Json;

public class ProductService
{
    public HttpClient _http;
    public List<Product>? lstProduct = new List<Product>();
    public string responseMessage = "";

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public async Task getAllProduct(string k = "")
    {
        string url = "https://svcy.myclass.vn/api/ProductApi/getall";
        if (!string.IsNullOrEmpty(k))
        {
            url = $"https://svcy.myclass.vn/api/ProductApi/getall?keyword={k}";
        }
        // Gọi API ở đây nếu cần
        lstProduct = await _http.GetFromJsonAsync<List<Product>>(url);
        Console.WriteLine($"{JsonSerializer.Serialize(lstProduct)}");
        //Gọi để giao diện cập nhật lại
        NotifyStateChanged();
    }

    public async Task<Product?> getProductById(string id)
    {
        // Gọi API ở đây nếu cần
        Product? res = await _http.GetFromJsonAsync<Product>(
            $"https://svcy.myclass.vn/api/ProductApi/get/{id}"
        );
        Console.WriteLine($"Dữ liệu từ API: {JsonSerializer.Serialize(res)}");
        //Gọi để giao diện cập nhật lại
        NotifyStateChanged();
        return res;
    }

    public async Task<int> createProduct(Product prd)
    {
        var response = await _http.PostAsJsonAsync(
            "https://svcy.myclass.vn/api/ProductApi/create",
            prd
        );
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //Thêm thành công
            await getAllProduct();
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 1;
        }
        else
        {
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 2;
        }
    }

    public async Task<int> updateProduct(Product prdUpdate, string id)
    {
        var response = await _http.PutAsJsonAsync(
            $"https://svcy.myclass.vn/api/ProductApi/update/{id}",
            prdUpdate
        );
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            //Thêm thành công
            await getAllProduct();
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 1;
        }
        else
        {
            responseMessage = response.Content.ReadAsStringAsync().Result;
            NotifyStateChanged();
            return 2;
        }
    }

    public async Task deleteProductById(string id)
    {
        // Gọi API ở đây nếu cần
        string? res = await _http.DeleteFromJsonAsync<string>(
            $"https://svcy.myclass.vn/api/ProductApi/delete/{id}"
        );

        //Gọi để giao diện cập nhật lại
        await getAllProduct();
    }
    
}
