<?php

include "Views/ViewRenderer.php";
include "Validators/ContactRequestValidator.php";

class ContactController
{
    public function __construct(IContainer $container) { }

    public function index() {
        ViewRenderer::render("Views/Contact/Index.php", "Contact me");
    }

    public function contactPost() {
        $validator = new ContactRequestValidator($_POST);
        $validator->validate();
        ViewRenderer::render("Views/Contact/Contact.php", "Contact me", $_POST);
    }
}