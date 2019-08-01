<template>
  <div>
    <h1>To Do</h1>
    <h3 v-if="message.length > 0">{{message}}</h3>
    <button v-on:click="onAdd">Add a Todo</button>
    <br />
    <br />
    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Task</th>
          <th>Complete</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{theTodo.id}}</td>
          <td>
            <input type="text" v-model="theTodo.task" />
          </td>
          <td>
            <input type="checkbox" v-model="theTodo.completed" />
          </td>
          <td>
            <button v-on:click="save">Save</button>
          </td>
        </tr>
        <tr v-for="todo in list" v-bind:key="todo.id">
          <td>{{todo.id}}</td>
          <td>{{todo.task}}</td>
          <td>{{todo.completed}}</td>
          <td>
            <button v-on:click="onEdit(todo.id)">Edit</button>
            <button v-on:click="deleteTheTodo(todo.id)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      list: [],
      apiURL: "http://5d4239c3bc64f90014a5685d.mockapi.io/api/todos",
      theTodo: {},
      message: ''
    };
  },
  computed: {
      maxId() {
          return this.list.reduce( (accum, item) => {return Math.max(accum, item.id)}, 0);
      },
      newTodo() {
          return { id: 0, task: "", completed: false };
      }
  },
  methods: {
    getList() {
      this.message = '';
      fetch(this.apiURL)
        .then(resp => {
          if (resp.ok) {
            resp.json().then(data => {
              this.list = data;
            });
          }
        })
        .catch((err) => {
          this.message = err;
        });
    },
    save() {
      this.message = '';
        if (this.theTodo.id === 0)
        {
            this.addTheTodo();
        }
        else
        {
            this.updateTheTodo();
        }
    },
    addTheTodo() {
        this.theTodo.id = this.maxId + 1;
        fetch(this.apiURL,
        {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(this.theTodo)
        }).then( (resp) => {
            if (resp.ok) {
                this.message = `Item ${this.theTodo.id} was added`;
                this.list.push(this.theTodo);
                this.theTodo = this.newTodo;
            }
        }).catch(
            (err) => {
                this.message = err;
            }
        )
    },
    updateTheTodo() {
        const url = `${this.apiURL}/${this.theTodo.id}`;
        fetch(url,
        {
            method: 'PUT',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(this.theTodo)
        }).then( (resp) => {
            if (resp.ok) {
                this.message = `Item ${this.theTodo.id} was updated`;
                //this.list.push(this.theTodo);
                this.theTodo = this.newTodo;
            }
            else {
                this.message = resp.statusText;
            }
        }).catch(
            (err) => {
                this.message = err;
            }
        )

    },
    deleteTheTodo(id) {
        const url = `${this.apiURL}/${id}`;
        fetch(url,
        {
            method: 'DELETE',
        }).then( (resp) => {
            if (resp.ok) {
                this.message = `Item ${id} was deleted`;
                //this.list.push(this.theTodo);
                this.theTodo = this.newTodo;
            }
            else {
                this.message = resp.statusText;
            }
        }).catch(
            (err) => {
                this.message = err;
            }
        )

    },
    onEdit(id) {
      this.message = '';
      let t = this.list.find(t => {
        return t.id === id;
      });
      this.theTodo = t;
    },
    onAdd() {
      this.message = '';
      this.theTodo = this.newTodo;
    }
  },

  created() {
    this.getList();
    this.theTodo = this.newTodo;
  }
};
</script>

<style>
</style>
