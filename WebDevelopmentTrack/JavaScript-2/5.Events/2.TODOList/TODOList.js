var todoList = (function () {
    var todoListElement = document.getElementById('todoList');
    var taskDisplay;
    var taskTextBox;
    var ownerTextBox;
    var todoList = [];
    createTodoForm();

    function createTodoForm() {
        var taskLabel = document.createElement('label');
        taskLabel.setAttribute('for', 'task-tb');
        taskLabel.innerText = 'Task';
        taskTextBox = document.createElement('input');
        taskTextBox.setAttribute('type', 'text');
        taskTextBox.setAttribute('id', 'task-tb');

        var ownerLabel = document.createElement('label');
        ownerLabel.setAttribute('for', 'owner-tb');
        ownerLabel.innerText = 'Owner';
        ownerTextBox = document.createElement('input');
        ownerTextBox.setAttribute('type', 'text');
        ownerTextBox.setAttribute('id', 'owner-tb');

        var addButton = document.createElement('button');
        addButton.setAttribute('onclick', 'todoList.addItem()');
        addButton.innerText = 'Add Task';

        var deleteButton = document.createElement('button');
        deleteButton.setAttribute('onclick', 'todoList.deleteChecked()');
        deleteButton.innerText = 'Delete checked';

        var showButton = document.createElement('button');
        showButton.setAttribute('onclick', 'todoList.show()');
        showButton.innerText = 'Show TODO List';

        var hideButton = document.createElement('button');
        hideButton.setAttribute('onclick', 'todoList.hide()');
        hideButton.innerText = 'Hide TODO List';

        taskDisplay = document.createElement('div');
        taskDisplay.style.border = '2px solid black';

        var docFragment = document.createDocumentFragment();
        docFragment.appendChild(taskLabel);
        docFragment.appendChild(taskTextBox);
        docFragment.appendChild(ownerLabel);
        docFragment.appendChild(ownerTextBox);
        docFragment.appendChild(document.createElement('br'));

        docFragment.appendChild(addButton);
        docFragment.appendChild(deleteButton);
        docFragment.appendChild(showButton);
        docFragment.appendChild(hideButton);

        docFragment.appendChild(taskDisplay);
        todoListElement.appendChild(docFragment);
    }

    function showTodoList() {
        deleteAllChild(taskDisplay);
        var docFragment = document.createDocumentFragment();
        var todoEntry;

        for (var i = 0, length = todoList.length; i < length; i++) {
            todoEntry = document.createElement('div');
            todoEntry.innerHTML = '<input type="checkbox" /><span>Owner: </span><strong>' + todoList[i].owner + '</strong><br />' +
                '<span>Task:<span><p>' + todoList[i].task + '</p>';
            todoEntry.setAttribute('id', i);
            docFragment.appendChild(todoEntry);
        }
        taskDisplay.appendChild(docFragment);
    }

    function addItem() {
        var currentTodo = {
            task: taskTextBox.value,
            owner: ownerTextBox.value
        }
        todoList.push(currentTodo);
        showTodoList();
    }

    function deleteChecked() {
        var todoEntry = taskDisplay.firstChild;
        var deletedEntriesCount = 0;
        while (todoEntry) {
            if (todoEntry.querySelector('input[type="checkbox"]').checked) {
                var todoEntryId = todoEntry.id ^ 0;
                todoEntryId -= deletedEntriesCount;
                deletedEntriesCount++;
                todoList.splice(todoEntryId, 1);
            }
            todoEntry = todoEntry.nextElementSibling;
        }

        showTodoList();
    }

    function show() {
        taskDisplay.style.display = '';
    }

    function hide() {
        taskDisplay.style.display = 'none';
    }

    function deleteAllChild(element) {
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }

    return {
        addItem: addItem,
        deleteChecked: deleteChecked,
        show: show,
        hide: hide
    }
}());