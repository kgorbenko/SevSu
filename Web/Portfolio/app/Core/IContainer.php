<?php

interface IContainer {
    function resolve(string $service);
}