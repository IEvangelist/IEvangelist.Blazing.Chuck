window.speak = (message) => {
    const utterance = new SpeechSynthesisUtterance(message);

    utterance.volume = 1;
    utterance.rate = 1;

    speechSynthesis.speak(utterance);
};