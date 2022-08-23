import { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useQueryClient, useMutation } from "react-query";
import { addTodo } from "../api";

function AddTodo() {
    const [title, setTitle] = useState("");

    const queryClient = useQueryClient();

    const { mutate } = useMutation(addTodo, {
        onSuccess: (res) => {
            queryClient.invalidateQueries(["todos"]);
            setTitle("");
        },
    });

    function addHandler(e) {
        e.preventDefault();

        if (!title.trim()) return;

        mutate({ title });
    }

    return (
        <div className="d-flex flex-column">
            <h1 className="display-6 text-center mt-5 mb-3">Add Todo</h1>
            <Form className="align-self-center w-75">
                <Form.Control
                    type="text"
                    className="mb-3"
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                />
                <Button type="submit" variant="outline-dark" className="w-100" onClick={addHandler}>
                    Add Todo
                </Button>
            </Form>
        </div>
    );
}

export default AddTodo;
