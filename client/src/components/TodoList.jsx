import React from "react";
import Todo from "./Todo";
import { useQuery } from "react-query";
import { fetchTodos } from "../api";

function TodoList() {
    const query = useQuery(["todos"], fetchTodos);

    return (
        <div className="px-5">
            <h1 className="text-center display-6">Todo List</h1>

            {query?.data?.map((todo) => (
                <Todo key={todo.id} todo={todo} />
            ))}
        </div>
    );
}

export default TodoList;
