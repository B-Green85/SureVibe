# SureVibe

**Sure** = certainty.  
**Vibe** = intuition.

SureVibe is a desktop app for **AI-assisted software development** that deterministically compiles human-written descriptive intent into strict, machine-readable JSON or YAML **agent instruction contracts**.

There is no AI inside SureVibe.  
No inference. No network. No magic.

SureVibe exists to take *vibes* — informal, human, intuitive direction — and turn them into **explicit instructions** that AI coding agents (Claude Code, Codex, Cursor, etc.) can execute precisely and predictably.

---

## Why SureVibe Exists

Modern AI coding tools are powerful, but they fail most often for one reason:

> Ambiguous intent.

SureVibe addresses that gap by forcing intent to be:
- explicit
- scoped
- structured
- reviewable
- copy-pasteable

This lets AI agents show their **engineering capability**, not their guesswork — and lets developers stay in control.

---

## Who This Is For

**SureVibe is for:**

- Developers using AI tools who want **deterministic outcomes**, not vibes
- “Vibe coders” who want a bridge from intuition to structure
- Senior engineers and “oldheads” who distrust AI unless it is **constrained**
- Anyone who believes:
  > *AI should execute instructions, not invent them*

**This is not a beginner tutorial tool.**  
Some thought is required. That’s intentional.

SureVibe does not remove thinking — it **preserves it**.

---

## What SureVibe Is (and Is Not)

### SureVibe **is**
- A deterministic instruction compiler
- A UI for producing copy-ready JSON/YAML agent specs
- A way to lock intent *before* handing work to an AI
- A demonstration that constraints unlock better AI results

### SureVibe **is not**
- An AI prompt generator
- A chatbot
- An autonomous agent
- A replacement for engineering judgment

---

## Usage

1. Fill in the input fields on the left:
   - Goal
   - Scope
   - Repo Layout
   - Constraints
   - Task and verification lists
2. Press **Compile**.
3. The right panel shows deterministic JSON or YAML output.
4. Toggle formats using the JSON/YAML selector.
5. Copy the output and paste it into your AI coding tool.

---

## List Field Conventions

- One item per line
- Blank lines are ignored
- Lines starting with `#` are treated as comments and ignored
- Leading and trailing whitespace is trimmed
- Order is preserved

---

## Build & Run

```bash
dotnet run --project SureVibe.App
```

## Requirements

- .NET 10 SDK
- macOS, Windows, or Linux

## Philosophy (Short Version)
AI should not guess what you mean.
It should execute what you decided.
