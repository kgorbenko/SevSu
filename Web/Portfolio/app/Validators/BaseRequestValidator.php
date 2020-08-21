<?php


abstract class BaseRequestValidator {
    protected array $post;

    public function __construct($post) {
        if (empty($post)) {
            http_response_code(ResponseCodes::$badRequestStatusCode);
            die();
        }
        $this->post = $post;
    }
}