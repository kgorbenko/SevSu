<?php

include "Views/ViewRenderer.php";

class ContactController
{
    public function __construct(IContainer $container) { }

    public function index() {
        ViewRenderer::render("Views/Contact/Index.php", "Contact me");
    }

    public function contactPost() {
        ViewRenderer::render("Views/Contact/Contact.php", "Contact me", $_POST);
    }
}