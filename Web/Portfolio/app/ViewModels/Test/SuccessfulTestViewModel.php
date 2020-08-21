<?php


class SuccessfulTestViewModel {
    public bool $areAnswersCorrect;

    public function __construct(bool $areAnswersCorrect) {
        $this->areAnswersCorrect = $areAnswersCorrect;
    }
}