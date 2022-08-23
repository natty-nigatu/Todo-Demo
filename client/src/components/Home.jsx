import React from "react";
import { Col, Container, Row } from "react-bootstrap";
import AddTodo from "./AddTodo";
import TodoList from "./TodoList";

function Home() {
    return (
        <Container fluid>
            <Row>
                <Col>
                    <AddTodo />
                </Col>
                <Col>
                    <TodoList />
                </Col>
            </Row>
        </Container>
    );
}

export default Home;
