using Microsoft.VisualStudio.TestTools.UnitTesting;
using Professional.Coding.Farm.Domain.TodoManagement;
using Shouldly;
using System.Linq;

namespace Domain.Test
{
    [TestClass]
    public class TodoListTest
    {
        [TestMethod]
        public void Create()
        {
            TodoList todoList = new TodoList("test");

            todoList.Title.ShouldBe("test");
            todoList.IsEnabled.ShouldBeTrue();
            todoList.Colour.ShouldBe(Colour.Yellow);
        }

        [TestMethod]
        public void AddItem()
        {
            TodoList todoList = new TodoList("test");

            todoList.AddItem("testItem");

            todoList
                .TodoItems
                .SingleOrDefault(i => i.Title == "testItem")
                .ShouldNotBeNull();
        }
    }
}
