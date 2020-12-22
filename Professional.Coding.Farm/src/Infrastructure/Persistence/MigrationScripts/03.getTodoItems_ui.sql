CREATE VIEW getTodoItems_ui
as
select	Id,
		TodoListId,
		Title,
		IsDone,
		IsEnabled,
		Note
from	TodoItems;