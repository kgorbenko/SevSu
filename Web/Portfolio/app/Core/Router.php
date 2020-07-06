<?php

class Router
{
    static function route()
    {
        $controllerName = array_key_exists("controller", $_REQUEST) ? $_REQUEST["controller"] : "Home";
        $actionName = array_key_exists("action", $_REQUEST) ? $_REQUEST['action'] : "index";

        $controllerFileName = "Controllers/" . $controllerName . 'Controller.php';
        if (file_exists($controllerFileName)) {
            include $controllerFileName;
        } else {
            http_response_code(404);
            die();
        }

        $controllerClassName = ucfirst($controllerName) . 'Controller';
        $controller = new $controllerClassName;

        if (method_exists($controller, $actionName)) {
            $controller->$actionName();
        } else {
            http_response_code(404);
            die();
        }
    }
}