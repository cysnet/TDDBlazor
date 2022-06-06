using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBlazorServer.Data;
using TodoBlazorServer.Repositories;
using TodoBlazorServer.Services;
using Xunit;

namespace TodoBlazorServerTest.Services
{
    public class TodoServiceTest
    {
        [Fact]
        public void GetTodoListTest()
        {
            //1.需要一个访问数据库的类
            var todoReposotory = new Mock<ITodoRepository>();
            todoReposotory.Setup(m => m.GetTodoList()).Returns(new List<TodoItem> {
                new TodoItem { Name = "1",Done = false },
                new TodoItem { Name = "2", Done = false },
                new TodoItem { Name = "2", Done = false }
            });

            ITodoService todoService = new TodoService(todoReposotory.Object);
            List<TodoGroupInfo> todoList = todoService.GroupByTodoList();

            Assert.Collection(todoList,
                t =>
                {
                    t.Key = "1";
                    t.Count = 1;
                },
                t =>
                {
                    t.Key = "2";
                    t.Count = 2;
                });
        }
    }
}
