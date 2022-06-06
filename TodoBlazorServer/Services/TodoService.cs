using TodoBlazorServer.Data;
using TodoBlazorServer.Repositories;

namespace TodoBlazorServer.Services
{
    public interface ITodoService
    {
        List<TodoGroupInfo> GroupByTodoList();
    }
    public class TodoService: ITodoService
    {
        private ITodoRepository _todoReposotory { get; set; }
        public TodoService(ITodoRepository todoReposotory)
        {
            _todoReposotory = todoReposotory;
        }

        public List<TodoGroupInfo> GroupByTodoList()
        {
            return _todoReposotory.GetTodoList()
                .GroupBy(e => e.Name)
                .Select(p => new TodoGroupInfo { Key = p.Key, Count = p.Count() })
                .ToList();
        }
    }
}
