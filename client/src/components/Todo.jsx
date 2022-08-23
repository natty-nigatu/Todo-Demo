import React from "react";
import { Card, Button } from "react-bootstrap";
import { useQueryClient, useMutation } from "react-query";
import { checkTodo, deleteTodo } from "../api";

function Todo({ todo }) {
    const queryClient = useQueryClient();

    const { mutate: deleteMutate } = useMutation(deleteTodo, {
        onSuccess: (res) => queryClient.invalidateQueries(["todos"]),
    });

    const { mutate: checkMutate } = useMutation(checkTodo, {
        onSuccess: (res) => queryClient.invalidateQueries(["todos"]),
    });

    function checkHandler() {
        checkMutate({ ...todo, isCompleted: !todo.isCompleted });
    }

    function deleteHandler(e) {
        e.stopPropagation();
        deleteMutate(todo.id);
    }

    return (
        <Card
            border={todo.isCompleted ? "light" : "dark"}
            className="border-2 mb-2 "
            onClick={checkHandler}
            style={{ cursor: "pointer" }}
        >
            <Card.Body className="d-flex justify-content-between p-2 ps-3">
                <Card.Title
                    className={
                        todo.isCompleted
                            ? "display-6 fs-4 text-decoration-line-through text-secondary"
                            : "display-6 fs-4"
                    }
                >
                    {todo.title}
                </Card.Title>
                <Button variant="outline-danger" className="border-0" onClick={deleteHandler}>
                    Delete
                </Button>
            </Card.Body>
        </Card>
    );
}

export default Todo;
