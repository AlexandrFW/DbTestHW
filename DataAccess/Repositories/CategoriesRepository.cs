using DbTestHW.Domain.Interfaces.Repositories;
using DbTestHW.Domain;
using AutoMapper;
using DbTestHW.DataAccess.Dto;

namespace DbTestHW.DataAccess.Repositories;

internal class CategoriesRepository : IRepository<Category>
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CategoriesRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }
    public Category? AddItem(Category item)
    {
        var category = _mapper.Map<CategoryDto>(item);
        var categoryAdded = _appDbContext.Categories.Add(category);

        _appDbContext.SaveChangesAsync();

        return GetById(categoryAdded.Entity.CategoryId);
    }

    public void DeleteItem(int id)
    {
        var category = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        if (category is not null)
        {
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChangesAsync();
        }
    }

    public Category? EditItem(Category item)
    {
        var category = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == item.CategoryId);

        if (category is not null)
        {
            category.CategoryName = item.CategoryName;

            _appDbContext.Categories.Update(category);
            _appDbContext.SaveChangesAsync();

            return _mapper.Map<Category>(category);
        }

        return null;
    }

    public Category? GetById(int id)
    {
        var category = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        if (category is not null)
        {
            return _mapper.Map<Category>(category);
        }

        return null;
    }

    public List<Category?> GetCollection()
    {
        var categories = _appDbContext.Categories.ToList();

        if (categories is not null)
            return _mapper.Map<List<Category>>(categories);
        else
            return (List<Category?>)Enumerable.Empty<Category>();
    }
}