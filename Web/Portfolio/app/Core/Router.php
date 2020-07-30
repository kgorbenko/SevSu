<?php

include "Container.php";
include "ResponseCodes.php";

class Router
{
    protected static $actionPrefixesByMethod = array(
        "GET" => "",
        "POST" => "Post"
    );

    static function route($request, $requestMethod) {
        $controllerName = self::getControllerName($request);
        $actionName = self::getActionName($request, $requestMethod);

        if ($requestMethod != "GET" && $requestMethod != "POST") {
            http_response_code(ResponseCodes::$notAllowedMethodStatusCode);
            die();
        }

        $controllerFileName = "Controllers/" . $controllerName . 'Controller.php';
        if (file_exists($controllerFileName)) {
            include $controllerFileName;
        } else {
            http_response_code(ResponseCodes::$notFoundStatusCode);
            die();
        }

        $controllerClassName = ucfirst($controllerName) . 'Controller';
        $container = Container::getInstance();
        $controller = new $controllerClassName($container);

        if (method_exists($controller, $actionName)) {
            $controller->$actionName();
        } else {
            http_response_code(ResponseCodes::$notFoundStatusCode);
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