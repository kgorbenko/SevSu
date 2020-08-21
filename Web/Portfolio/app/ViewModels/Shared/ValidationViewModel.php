<?php


class ValidationViewModel {
    public bool $isValid;
    public array $errors;

    public function __construct(bool $isValid, array $errors) {
        $this->isValid = $isValid;
        $this->errors = $errors;
    }
}