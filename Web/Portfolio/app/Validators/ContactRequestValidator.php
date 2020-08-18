<?php

include "Validator.php";

class ContactRequestValidator {
    private $post;

    public function __construct($post) {
        if (empty($post)) {
            throw new InvalidArgumentException('$post');
        }
        $this->post = $post;
    }

    public function validate() {
        $validation = new Validation();
        $validation->name('full-name')->value($this->post['full-name'])->pattern('text')->required();
        $validation->name('email')->value($this->post['email'])->pattern('email')->required();
        $validation->name('phone')->value($this->post['phone'])->pattern('tel')->required();
        $validation->name('message')->value($this->post['message'])->pattern('text');
        $validation->name('date')->value($this->post['date'])->pattern('date_full_day')->required();

        if (!$validation->isSuccess()) {
            http_response_code(ResponseCodes::$badRequestStatusCode);
        }
    }
}