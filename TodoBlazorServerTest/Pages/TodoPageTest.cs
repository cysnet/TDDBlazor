using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBlazorServer.Data;
using TodoBlazorServer.Pages;
using TodoBlazorServer.Repositories;
using TodoBlazorServer.Services;
using Xunit;

namespace TodoBlazorServerTest.Pages
{
    public class TodoPageTest
    {
        [Fact]
        public void TodoGroupInfoTest()
        {
            using var ctx = new TestContext();
            ctx.Services.AddSingleton<ITodoService>(p =>
            {
                var todoService = new Mock<ITodoService>();
                todoService.Setup(m => m.GroupByTodoList()).Returns(new List<TodoGroupInfo> {
                    new TodoGroupInfo { Key = "readbooks", Count = 1000 }
                });
                return todoService.Object;
            });
            var cut = ctx.RenderComponent<TodoGroup>();
            cut.MarkupMatches(@"<h1>readbooks</h1><h2>1000</h2>");
        }
    }
}
