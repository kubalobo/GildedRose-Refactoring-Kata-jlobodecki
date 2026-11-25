import argparse
import xml.etree.ElementTree as ET


def main():
    parser = argparse.ArgumentParser(description="Require complete Gilded Rose updater coverage.")
    parser.add_argument("report", help="Cobertura report from updater-coverage.runsettings")
    args = parser.parse_args()

    coverage = ET.parse(args.report).getroot()
    complete = True
    for metric in ("lines", "branches"):
        covered = int(coverage.attrib[f"{metric}-covered"])
        total = int(coverage.attrib[f"{metric}-valid"])
        print(f"Updater {metric}: {covered}/{total} covered (100% required)")
        if total <= 0 or covered != total:
            complete = False

    return 0 if complete else 1


if __name__ == "__main__":
    raise SystemExit(main())
