using AutoMapper;
using MicroserviceECommerce.Catalog.WebAPI.Dtos.ProductDtos;
using MicroserviceECommerce.Catalog.WebAPI.Entities;
using MicroserviceECommerce.Catalog.WebAPI.Settings;
using MongoDB.Driver;

namespace MicroserviceECommerce.Catalog.WebAPI.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public ProductService(IDatabaseSettings _databaseSettings,  IMapper mapper)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductId == id);
    }

    public Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var value =  _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<Task<GetByIdProductDto>>(value);
    }

    public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();
        
        foreach (var item in values)
        {
            item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
        }

        return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
    }

    public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
    {
        var values = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();

        foreach (var item in values)
        {
            item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
        }

        return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
    }
}