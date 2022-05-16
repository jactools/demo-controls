class RecordCount:
    def __init__(self, expected, actual, slack_pct):
        self.name = "RecordCount"
        self.expected = expected
        self.actual = actual
        self.slack_pct = slack_pct

    def check(self):
        if self.actual == self.expected:
            return True
        else:
            return False

    def check_with_slack(self):
        if self.expected * (1 + self.slack_pct / 100) >= self.actual >= self.expected * (1 - self.slack_pct / 100):
            return True
        else:
            return False
