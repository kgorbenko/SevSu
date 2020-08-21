<?php


class ViewHelper {
    public static function normalizeErrors($errors) {
        $result = array();
        foreach ($errors as $key => $value) {
            foreach ($value as $nestedValue) {
                array_push($result, $nestedValue);
            }
        }

        return $result;
    }

    public static function writeValidationErrorsList($errors) {
        echo("<ul>");
        foreach (ViewHelper::normalizeErrors($errors) as $error) {
            echo("<li>$error</li>");
        }
        echo("</ul>");
    }
}