<?php

class Router
{
    protected static $notFoundStatusCode = 404;
    protected static $notAllowedMethodStatusCode = 405;

    protected static $actionPrefixesByMethod = array(
        "GET" => "",
        "POST" => "Post"
    );

    static function route($request, $requestMethod)
    {
        $controllerName = self::getControllerName($request);
        $actionName = self::getActionName($request, $requestMethod);


        $controllerFileName = "Controllers/" . $controllerName . 'Controller.php';
        if (file_exists($controllerFileName)) {
            include $controllerFileName;
        } else {
            http_response_code(self::$notFoundStatusCode);
            die();
        }

        $controllerClassName = ucfirst($controllerName) . 'Controller';
        $controller = new $controllerClassName;

        if (method_exists($controller, $actionName)) {
            $controller->$actionName();
        } else {
            http_response_code(self::$notFoundStatusCode);
            die();
        }
    }

    private static function getControllerName($request) {
        return array_key_exists("controller", $request)
            ? $request["controller"]
            : "Home";
    }

    private static function getActionName($request, $method) {
        if (!array_key_exists("action", $request)) {
            return "Index" . self::$actionPrefixesByMethod[$method];
        }

        return $request["action"] . self::$actionPrefixesByMethod[$method];
    }
}