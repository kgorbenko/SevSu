<?php


class TestRequestVerification {
    private array $post;

    public function __construct($post) {
        if (empty($post)) {
            throw new InvalidArgumentException("$post");
        }
        $this->post = $post;
    }

    public function verify() {
        $correctAnswers = array(
            'Question1' => '1',
            'Question2' => '2',
            'Question3' => 'Correct answer'
        );

        $areAnswersCorrect = true;
        foreach ($correctAnswers as $question => $answer) {
            if ($this->post[$question] != $answer) {
                $areAnswersCorrect = false;
            }
        }

        return $areAnswersCorrect;
    }
}