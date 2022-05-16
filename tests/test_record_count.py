from count_controls.record_count import RecordCount


def test_check():
    record_count = RecordCount(100, 100, 0)
    assert record_count.check()

    record_count = RecordCount(99, 100, 0)
    assert not record_count.check()


def test_check_with_slack():
    record_count = RecordCount(100, 100, 0)
    assert record_count.check_with_slack()

    record_count = RecordCount(99, 100, 5)
    assert record_count.check_with_slack()
