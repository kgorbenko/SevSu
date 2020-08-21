<?php

include "Views/Shared/ViewHelper.php";

class ViewRenderer
{
    static function render($viewName, $title, $viewModel = NULL, $layout = 'Layout.php')
    {
        include "Views/Shared/".$layout;
    }
}