<?php

include "IContainer.php";
include "Model/Repositories/PhotosRepository.php";

class Container implements IContainer
{
    private static $instance;

    public static function getInstance() {
        if (is_null(self::$instance)) {
            self::$instance = new Container();
        }
        return self::$instance;
    }

    private $photosRepository;

    private function __construct() {
        $this->photosRepository = new PhotosRepository();
    }

    function resolve(string $service) {
        switch ($service) {
            case "IPhotosRepository": return $this->photosRepository; break;
            default: http_response_code(ResponseCodes::$internalServerErrorStatusCode); die("Unknown service.");
        }
    }
}