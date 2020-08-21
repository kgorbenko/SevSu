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
}