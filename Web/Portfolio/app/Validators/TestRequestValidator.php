<?php

include "Valitron/Validator.php";
include "ValidationResult.php";

class TestRequestValidator {
    private array $post;

    public function __construct($post) {
        if (empty($post)) {
            throw new InvalidArgumentException('$post');
        }
        $this->post = $post;
    }

    public function validate() {
        $v = new Validator($this->post);
        $v->rule('required', ['Question1', 'Question2', 'Question3', 'Name', 'Email' ]);
        $v->rule('integer', 'Question1')->rule('in', 'Question1', [ 1, 2 ]);
        $v->rule('integer', 'Question2')->rule('in', 'Question2', [ 1, 2, 3 ]);
        $v->rule('regex', 'Name', '/[A-Za-z]+ [A-Za-z]+ [A-Za-z]+/');
        $v->rule('email', 'Email');

        $isValid = $v->validate();
        $errors = $v->errors();

        return new ValidationResult($isValid, $errors);
    }
}