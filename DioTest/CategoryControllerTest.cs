using System.Threading;
using System.Threading.Tasks;
using DioAPI.Controllers;
using DIOApplicationMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DioTest
{

    public class CategoryControllerTest
    {
        private readonly Mock<DbSet<Category>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Category _category;

        public CategoryControllerTest()
        {
            _mockSet = new Mock<DbSet<Category>>();
            _mockContext = new Mock<Context>();
            _category = new Category {Id = 1, Description = "Category Test"};

            _mockContext.Setup(m => m.Categories).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.Categories.FindAsync(1)).ReturnsAsync(_category);

            _mockContext.Setup(m => m.SetModified(_category));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        }

        [Fact]
        public async Task Get_Category()
        {
            var service = new CategoryController(_mockContext.Object);

            await service.GetCategory(1);
            _mockSet.Verify(m => m.FindAsync(1), Times.Once);
        }

        [Fact]
        public async Task Put_Category()
        {
            var service = new CategoryController(_mockContext.Object);
            await service.PutCategory(1, _category);
            
            _mockContext.Verify(m=>m.SaveChangesAsync(It.IsAny<CancellationToken>()),Times.Once);

        }

        [Fact]
        public async Task Post_Category()
        {
            var service = new CategoryController(_mockContext.Object);
            await service.PostCategory(_category);
            
            _mockSet.Verify(x=>x.Add(_category), Times.Once);
            _mockContext.Verify(m=>m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            
        }

        [Fact]
        public async Task Delete_Category()
        {
            var service = new CategoryController(_mockContext.Object);
            await service.DeleteCategory(1);
            
            _mockSet.Verify(m=>m.FindAsync(1), Times.Once);
            _mockSet.Verify(m=>m.Remove(_category), Times.Once);
            _mockContext.Verify(m=>m.SaveChangesAsync(It.IsAny<CancellationToken>()),Times.Once);
            
        }
    }
}