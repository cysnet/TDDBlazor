using TodoBlazorServer.Data;

namespace TodoBlazorServer.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetTodoList();
    }
    public class TodoRepository : ITodoRepository
    {
        public IEnumerable<TodoItem> GetTodoList() // 真实数据库操作，无需测试
        {
            return new List<TodoItem>() { new TodoItem { Name = "123" }, new TodoItem { Name = "456" } };
        }
    }
}
