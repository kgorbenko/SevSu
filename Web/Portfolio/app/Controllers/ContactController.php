<?php

include "Views/ViewRenderer.php";
include "Validators/ContactRequestValidator.php";
include "ViewModels/Contact/IndexViewModel.php";

class ContactController
{
    public function __construct(IContainer $container) {}

    public function index() {
        $viewModel = new IndexViewModel(true, array());
        ViewRenderer::render("Views/Contact/Index.php", "Contact me", $viewModel);
    }

    public function contactPost() {
        $validator = new ContactRequestValidator($_POST);
        $validationResult = $validator->validate();

        if ($validationResult->isValid) {
            ViewRenderer::render("Views/Contact/Contact.php", "Contact me");
        }

        $viewModel = new IndexViewModel($validationResult->isValid, $validationResult->errors);
        ViewRenderer::render("Views/Contact/Index.php", "Contact me", $viewModel);
    }
}