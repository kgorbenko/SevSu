<?php

include "Views/ViewRenderer.php";
include "Validators/TestRequestValidator.php";
include "ViewModels/Shared/ValidationViewModel.php";

class TestController {
    public function __construct(IContainer $container) {}

    public function index() {
        $viewModel = new ValidationViewModel(true, array());
        ViewRenderer::render("Views/Test/Index.php", "Test", $viewModel);
    }

    public function testPost() {
        $validator = new TestRequestValidator($_POST);
        $validationResult = $validator->validate();

        if ($validationResult->isValid) {
            ViewRenderer::render("Views/Test/Success.php", "Test");
        }

        $viewModel = new ValidationViewModel($validationResult->isValid, $validationResult->errors);
        ViewRenderer::render("Views/Test/Index.php", "Test", $viewModel);
    }
}