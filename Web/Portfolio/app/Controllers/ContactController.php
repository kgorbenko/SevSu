<?php

include "Views/ViewRenderer.php";

class ContactController
{
    public function index() {
        ViewRenderer::render("Views/Contact/Index.php", "Contact me");
    }
}