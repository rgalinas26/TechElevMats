#!/bin/bash

# This script assumes the student's repo has been cloned manually. The student 
# should have logged onto BitBucket.org, found their repo and cloned it. During that process,
# any issues with credentials (such as logging on with a Google-Id) would have been resolved.

# Change this to match your repository root
readonly TEAM_REPO="https://bitbucket.org/te-cle-cohort-11"
readonly cohort="c"

echo
read -r -p "Enter your name (First Last)? " name
read -r -p "Enter your email? " email

reponame=${name//[[:blank:]]/}

echo
echo "Setting Up Global Configuration Settings"

git config --global user.name "${name}"
git config --global user.email "${email}"

echo "Setting up Git Editors and Tools..."

git config --global core.editor "code -w -n"
git config --global diff.tool code
git config --global difftool.code.cmd "code -w -d \$LOCAL \$REMOTE"

echo
echo "Configuring Upstream..."

# cd "${reponame}-${cohort}"
git remote add upstream "${TEAM_REPO}/${cohort}-main"
git config branch.master.mergeOptions "--no-edit"

echo "Done."