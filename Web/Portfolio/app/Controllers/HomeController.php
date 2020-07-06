<?php

include "Views/ViewRenderer.php";

class HomeController
{
    public function index() {
        ViewRenderer::render("Views/Home/Index.php", "Homepage");
    }
}