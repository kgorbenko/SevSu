<?php

include "Views/ViewRenderer.php";
include "Validators/TestRequestValidator.php";
include "Validators/TestRequestVerification.php";
include "ViewModels/Shared/ValidationViewModel.php";
include "ViewModels/Test/SuccessfulTestViewModel.php";

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
            $testVerification = new TestRequestVerification($_POST);
            $viewModel = new SuccessfulTestViewModel($testVerification->verify());
            ViewRenderer::render("Views/Test/Success.php", "Test", $viewModel);
            return;
        }

        $viewModel = new ValidationViewModel($validationResult->isValid, $validationResult->errors);
        ViewRenderer::render("Views/Test/Index.php", "Test", $viewModel);
    }
}