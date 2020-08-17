<?php

class AboutViewModel
{
    public $photos;

    public function __construct($photos)
    {
        $this->photos = $photos;
    }
}