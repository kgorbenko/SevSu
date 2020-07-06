<?php

class ViewRenderer
{
    static function render($viewName, $title, $model = NULL, $layout = 'Layout.php')
    {
        include "Views/Shared/".$layout;
    }
}