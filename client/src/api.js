import axios from "axios";

const api = axios.create({ baseURL: "https://localhost:7062/" });

export const fetchTodos = () => api.get("/todo").then((res) => res.data);

export const deleteTodo = (data) => api.delete(`/todo?id=${data}`);

export const checkTodo = (data) => api.put("/todo", data);

export const addTodo = (data) => api.post("/todo", data);
